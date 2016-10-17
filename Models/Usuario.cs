using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Models
{
    [Serializable]
    public class Usuario
    {      
        public virtual long id { get; set; }

        [Required(ErrorMessage = "Informe o nome")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Campo nome deve ter de 5 a 50 caracteres")]
        public virtual String nome { get; set; }

        [Remote("isExistEmail", "usuarios", AdditionalFields = "id", HttpMethod = "get", ErrorMessage = "Email já cadastrado!")]
        [EmailAddress(ErrorMessage = "Digite um e-mail válido")]
        public virtual string email { get; set; }

        [Required(ErrorMessage = "Informe a senha")]        
        public virtual string senha { get; set; }

        //1 ativo, 2 inativo, 0 aguardando
        public virtual int status { get; set; }                          

    }
}
