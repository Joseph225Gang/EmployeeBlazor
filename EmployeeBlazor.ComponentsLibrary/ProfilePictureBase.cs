using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBlazor.ComponentsLibrary
{
    public class ProfilePictureBase : ComponentBase
    {
        protected string CssClass { get; set; } = "circle";
        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
