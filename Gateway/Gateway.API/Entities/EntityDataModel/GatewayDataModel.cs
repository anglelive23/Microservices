namespace Gateway.API.Entities.EntityDataModel
{
    public class GatewayDataModel
    {
        public IEdmModel GetGatewayDataModel()
        {
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<Client>("Clients");
            builder.EntitySet<Service>("Offers");
            builder.EntitySet<Employee>("Employees");
            builder.EntitySet<Project>("Projects");

            return builder.GetEdmModel();
        }
    }
}
