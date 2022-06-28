using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BlogWebApi.Extensions
{
    public static class ModelStateExtension
    {
        public static List<string> GetErrors(this ModelStateDictionary modelStateDictionary)
        {
            return (from item in modelStateDictionary.Values from error in item.Errors select error.ErrorMessage).ToList();
        }
    }
}
