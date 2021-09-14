using ImpulsoProject.Users;
using ImpulsoProject.Users.Dto;
using System.Threading.Tasks;

namespace ImpulsoProject.DAL
{
    public class Users
    {
        private readonly UserAppService _userAppService;
        public Users(UserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        public Users()
        {

        }
        //public async Task<UserDto> CreateUserTest(CreateUserDto input)
        //{
        //    //CreateUserDto input = new CreateUserDto
        //    //{
        //    //    Name = "Dev",
        //    //    EmailAddress = "teste.@teste.com",
        //    //    IsActive = true,
        //    //    Password = "teste123",
        //    //    RoleNames = new[] { "admin" },
        //    //    Surname = "Testetador",
        //    //    UserName = "Tester"

        //    //};

        //    var result = await _userAppService.CreateAsync(input);
                      
        //    return result;
        //}

        public void CreateUserTest(CreateUserDto input)
        {
            var result =  _userAppService.CreateAsync(input);

        }



    }
}
