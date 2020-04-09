namespace Core.Model
{
    public class PaginatorResponse<T>
    {
        public PaginatorResponseModel<T> PaginatorModel { get; set; }

        public PaginatorResponse()
        {
            PaginatorModel = new PaginatorResponseModel<T>();
        }
    }
}
