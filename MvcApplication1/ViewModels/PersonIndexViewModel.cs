using System.Collections.Generic;
using MvcApplication1.Core;

namespace MvcApplication1.ViewModels
{
    public class PersonIndexViewModel : BaseViewModel
    {
        public List<PersonViewModel> PersonViewModels { get; set; }
    }
}