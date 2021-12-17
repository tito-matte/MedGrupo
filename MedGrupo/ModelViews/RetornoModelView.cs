using System.Collections.Generic;

namespace Apl.ERP.API.ModelViews
{
    public class RetornoModelView
    {
        public RetornoModelView()
        {
            Messages = new List<string>();
        }

        public int ReturnCode { get; set; }
        public List<string> Messages { get; set; }
        public object ReturnObject { get; set; }
    }
}
