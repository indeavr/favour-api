namespace FavourAPI.Dtos
{
    public class PermissionsMyDto
    {
        public bool HasSufficientInfoConsumer { get; set; }

        public bool HasSufficientInfoProvider { get; set; }

        public bool CanApplyConsumer { get; set; }
    }
}
