using Dapper;
using DeppoControlBackend.Entities.Dto;
using DeppoControlBackend.Entities.Model;
using DeppoControlBackend.Repository;
using DeppoControlBackend.Result;
using System.Text;

namespace DeppoControlBackend.Services
{
    public class DeppoCheck
    {
        public async Task<IDataResult<LicencesModel>> GetLicenceInfo(GetLicenceDto param)
        {
            // Check User Information
            DapperRepository<UsersModel> userRepository = new DapperRepository<UsersModel>();
            DynamicParameters userParameters = new DynamicParameters();
            userParameters.Add("@Username", param.Username);

            var userResult = await userRepository.FirstOrDefaultAsync("select * from users where username=@username", userParameters);

            var user = userResult.Data;

            if (!userResult.Success)
                return new ErrorDataResult<LicencesModel>($"Kullanıcı bilgileri alınırken bir hata meydana geldi. Hata Detayı : {userResult.Message}");

            if (user == null)
                return new ErrorDataResult<LicencesModel>("Girilen kullanıcı geçerli değil. Lütfen kullanıcı adınızın doğru olduğuna emin olunuz.");

            if (user.Password != param.Password)
                return new ErrorDataResult<LicencesModel>("Girilen parola ve kullanıcı adı eşleşmemektedir. Parolanızı doğru girdiğinize emin olunuz.");

            // Check licence information 
            DapperRepository<LicencesModel> licenceRepository = new DapperRepository<LicencesModel>();
            DynamicParameters licenceParameters = new DynamicParameters();
            licenceParameters.Add("@LicenceKey", param.LicenceKey);

            var licenceResult = await licenceRepository.FirstOrDefaultAsync("select * from Licences where LicenceKey=@LicenceKey", licenceParameters); 

            var licence = licenceResult.Data;

            //if (!licenceResult.Success)
            //    return new ErrorDataResult<LicencesModel>($"Lisans bilgileri alınırken bir hata meydana geldi. Hata Detayı : {licenceResult.Message}");

            if (licence == null)
                return new ErrorDataResult<LicencesModel>("Girilen lisans anahtarı geçerli değil. Lütfen lisans anahtarınızın doğru olduğuna emin olunuz.");

            String licenceKey = param.LicenceKey;
            Guid result = new Guid(licenceKey);
            GetProductKeyDto getKey = new GetProductKeyDto();

            if (licence.LicenceKey != result)
                return new ErrorDataResult<LicencesModel>("Girdiğiniz lisans anahtarıyla firma eşleşmesi yapılamadı. Lütfen firma bilgilerini doğru girdiğinize emin olunuz.");

            if (licence.VKN_TCKN != param.VKN_TCKN)
                return new ErrorDataResult<LicencesModel>("Girdiğiniz VKN/TCKN bilgisi hatalıdır. Lütfen bilgileri doğru girdiğinize emin olunuz.");

            if (!licence.Active)
                return new ErrorDataResult<LicencesModel>("Girdiğiniz lisans aktif değildir.");


            return new SuccessDataResult<LicencesModel>(licenceResult.Data);

        }
        public string GetEncryptedLicenceKey(GetProductKeyDto param)
        {
                Encoding encoder = Encoding.UTF8;
                byte[] bs = encoder.GetBytes(param.ProductKey);

                string encoded = "";

                int i = 0;

                foreach (byte b in bs)
                {
                    Math.DivRem(i, 3, out int j);
                    if ((j != 0) || (i == 0))
                    {
                        if (b.ToString().Length < 4)
                        {
                            encoded += b.ToString().PadLeft(4, '0');
                        }
                        else
                        {
                            encoded += b.ToString();
                        }
                    }
                    else
                    {
                        if (b.ToString().Length < 4)
                        {
                            encoded += "-" + b.ToString().PadLeft(4, '0');
                        }
                        else
                        {
                            encoded += "-" + b.ToString();
                        }
                    }
                    i++;
                }
                return encoded;           
        }

        public string GetEncryptedModuleLicenceKey(GetModuleKeyDto param)
        {
            Encoding encoder = Encoding.UTF8;
            byte[] bs = encoder.GetBytes(param.ModuleProductKey);

            string encoded = "";

            int i = 0;

            foreach (byte b in bs)
            {
                Math.DivRem(i, 3, out int j);
                if ((j != 0) || (i == 0))
                {
                    if (b.ToString().Length < 4)
                    {
                        encoded += b.ToString().PadLeft(4, '0');
                    }
                    else
                    {
                        encoded += b.ToString();
                    }
                }
                else
                {
                    if (b.ToString().Length < 4)
                    {
                        encoded += "-" + b.ToString().PadLeft(4, '0');
                    }
                    else
                    {
                        encoded += "-" + b.ToString();
                    }
                }
                i++;
            }
            return encoded;
        }
    }
}
