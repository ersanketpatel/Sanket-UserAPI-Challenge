using System.Collections.Generic;

namespace TestProject.WebAPI.ViewModel
{
    public class ModelValidate 
    {
        public bool IsSuccess { get; set; }
        public List<string> ErrorMessage { get; set; }

        public object Result { get; set; }
    }
}
