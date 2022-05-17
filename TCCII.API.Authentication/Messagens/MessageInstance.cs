using System.ComponentModel;

namespace TCCII.API.Authentication.API.Messages
{
    public enum MessageInstanceSuccess
    {
        [Description("Deputados criados com sucesso!")]
        SuccessCreateDeputados = 1001,

        [Description("Senha alterada com sucesso!")]
        SuccessChangePassword = 1002,

        [Description("Email para redefinição de senha foi enviado com sucesso!")]
        SuccessForgetPassword = 1003,

        [Description("Usuário atualizado com sucesso!")]
        SuccessUpdatedUser = 1004,

    }

    public enum MessageInstanceFailed
    {
        [Description("Usuário não encontrado!")]
        UserNotFound = 4001,

        [Description("Email não encontrado!")]
        EmailNotFound = 4002,

        [Description("Usuario ou Senha inválidos!")]
        InvalidUserOrPassword = 4003,

        [Description("Código do token inválido!")]
        InvalidToken = 4004,

        [Description("Não foi possível alterar a senha!")]
        FailedChangePassword = 4005,

        [Description("Falha ao tentar efetuar o cadastro de usuário.")]
        FailedRegisterUser = 4006,

        [Description("Não foi possivel atualizar o usuário!")]
        FailedUpdatedUser = 4007,                
    }


    static class MessageInstanceExtension
    {
        public static string GetDescription(this Enum e)
        {
            var eType = e.GetType();
            var eName = Enum.GetName(eType, e);
            if (eName != null)
            {
                var fieldInfo = eType.GetField(eName);
                if (fieldInfo != null)
                    if (Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute)) is DescriptionAttribute descriptionAttribute)
                        return descriptionAttribute.Description;
            }
            return String.Empty;
        }
    }
}
