using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Wpf_Student_Management
{
    public class MainVM: ObservableObject
    {
        private PageId _pageId;
        public PageId PageId
        {
            get { return _pageId; } 
            set { SetProperty(ref _pageId, value); }  
        }

        public ICommand CMDChangePage => new RelayCommand<PageId>(ChangePage);

        void ChangePage(PageId newPage)
        {
            PageId = newPage;
        }

        public MainVM()
        {
            PageId = PageId.Student;
        }
    }
}
