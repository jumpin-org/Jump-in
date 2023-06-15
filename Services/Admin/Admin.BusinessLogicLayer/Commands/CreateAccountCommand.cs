using JumpIn.Common.Domain.BusinessLogicLayer;

namespace JumpIn.Admin.BusinessLogicLayer.Commands
{
    public class CreateAccountCommand : ICommand<int>
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public byte[]? IDDocument { get; set; }
        public byte[]? ProofAddress { get; set; }
    }
}
