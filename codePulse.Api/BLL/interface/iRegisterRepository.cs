using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface iRegisterRepository
{

    Task<RegisterDto> CreateAsync(RegisterDto register);
    List<RegisterDto> GetAll();

    Task<RegisterDto> GET();
}
}

