using System.Collections.Generic;

namespace MvcApplication1.ViewModels
{
    public class PersonIndexViewModel : BaseViewModel
    {
        public List<PersonViewModel> PersonViewModels { get; set; }
    }
}