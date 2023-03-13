namespace Gateway.API.Entities.EntityDataModel
{
    public class GatewayDataModel
    {
        public IEdmModel GetGatewayDataModel()
        {
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<ClientResponseDto>("Clients");
            builder.EntitySet<ServicesResponseDto>("Offers");
            builder.EntitySet<EmployeeResponseDto>("Employees");
            builder.EntitySet<ProjectResponseDto>("Projects");

            return builder.GetEdmModel();
        }
    }
}
