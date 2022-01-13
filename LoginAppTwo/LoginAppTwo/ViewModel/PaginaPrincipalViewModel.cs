using LoginAppTwo.Models;
using LoginAppTwo.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoginAppTwo.ViewModel
{
    class PaginaPrincipalViewModel
    {
        public User CurremtUser { get; set; }


        public PaginaPrincipalViewModel()
        {
            GetUser();
        }


        public async void GetUser()
        {
            GetInfoService service = new GetInfoService();

            CurremtUser = await service.GetUser();

        }
    }
}
