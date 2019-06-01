using FavourAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace FavourAPI.Services.Helpers.Seeder
{
    public interface ICanAddCount<TEntity> where TEntity : class
    {
        ICanAddColumn<TEntity> RowsCount(int count);
    }

    public interface ICanAddColumn<TEntity> where TEntity : class
    {
        ICanAddSetCollection<TEntity> Column<TProperty>(Expression<Func<TEntity, TProperty>> selector);
    }

    public interface ICanAddSetCollection<TEntity> where TEntity : class
    {
        ICanAddColumnOrApply<TEntity> SetCollection<TProperty>(Expression<Func<ICollection<TProperty>>> generate);
    }

    public interface ICanAddColumnOrApply<TEntity> : ICanAddColumn<TEntity> where TEntity : class
    {
        void Apply();
    }

    public class TableSeeder<TEntity> : ICanAddCount<TEntity>, ICanAddColumn<TEntity>,
                                        ICanAddSetCollection<TEntity>, ICanAddColumnOrApply<TEntity>
                        where TEntity : class
    {
        private int fieldsCount;
        private TEntity[] entities;
        private PropertyInfo columnProp;
        private readonly WorkFavourDbContext context;

        private TableSeeder([FromServices] WorkFavourDbContext workFavourDbContext)
        {
            this.context = workFavourDbContext;
        }

        private int FieldsCount
        {
            get => this.fieldsCount;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Number of fields must be at leatst 1");

                this.fieldsCount = value;
            }
        }

        #region Initiating Methods

        public static ICanAddCount<TEntity> ToContext(WorkFavourDbContext workFavourDbContext)
        {
            return new TableSeeder<TEntity>(workFavourDbContext);
        }

        #endregion

        #region Chaining Methods

        public ICanAddColumn<TEntity> RowsCount(int count)
        {
            this.FieldsCount = count;
            this.entities = new TEntity[this.FieldsCount];

            for (int i = 0; i < this.FieldsCount; i++)
            {
                entities[i] = (TEntity)Activator.CreateInstance(typeof(TEntity));
            }

            return this;
        }

        public ICanAddSetCollection<TEntity> Column<TProperty>(Expression<Func<TEntity, TProperty>> selector)
        {
            this.columnProp = (PropertyInfo)((MemberExpression)selector.Body).Member;

            return this;
        }

        public ICanAddColumnOrApply<TEntity> SetCollection<TProperty>(Expression<Func<ICollection<TProperty>>> generate)
        {
            ICollection<TProperty> seedCol = generate.Compile()();

            if (seedCol.Count < this.FieldsCount)
                throw new ArgumentOutOfRangeException($"The count of the elements in collection are {seedCol.Count}. They must be at least {this.FieldsCount}. ");

            seedCol = seedCol.Take(this.FieldsCount).ToList();

            int row = 0;
            foreach (TProperty value in seedCol)
            {
                if (entities[row] == null)
                {
                    entities[row] = (TEntity)Activator.CreateInstance(typeof(TEntity));
                }

                columnProp.SetValue(entities[row], value, null);
                row++;
            }

            return this;
        }

        #endregion

        #region Executing Methods

        public void Apply()
        {
            //Type entityType = typeof(TEntity);
            //DbSet<TEntity> dbSet = (DbSet<TEntity>)this.context.GetType().GetMethod("Set").MakeGenericMethod(entityType).Invoke(this.context, null);

            context.Set<TEntity>().AddRange(entities);

            context.SaveChanges();
        }

        #endregion
    }
}
