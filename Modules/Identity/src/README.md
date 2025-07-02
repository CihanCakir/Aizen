ChangePassword               ForgotPassword               ProfileImageModifie          SendActivition               UpdateUserProfileInformation
ChangeSignPrefer             LoginWithCardNumber          ProfileModifie               SendOtp                      UserFavoriteMerchantAdd
CheckOtp                     LoginWithOtp                 RefreshLogin                 SendOtpWithCardNo            UserFavoriteMerchantDelete
CheckPassword                LoginWithPhoneNumber         RegisterAccount              UpdateMessagePermissions





dotnet ef migrations add 2025_07_02_1 --startup-project ./src/Aizen.Modules.Identity/ --project ./src/Aizen.Modules.Identity.Repository/ --context AizenIdentityDbContext

dotnet ef database update  --startup-project ./src/Aizen.Modules.Identity/ --project ./src/Aizen.Modules.Identity.Repository/ --context AizenIdentityDbContext