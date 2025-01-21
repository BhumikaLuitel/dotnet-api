using Microsoft.AspNetCore.Mvc;
namespace FirstC_.Controllers; 
public class BankAccountController : ControllerBase
    {
        public static List<BankAccount> BankAccounts = new List<BankAccount>();

        [HttpPost("/api/bankaccount")]
        public IActionResult Create([FromBody] BankAccountDto a)
        {
            try
            {
                var account = new BankAccount
                {
                    Id = BankAccounts.Count + 1,
                    AccountName = a.AccountName,
                    AccountNumber = a.AccountNumber,
                    Balance = a.Balance
                };
                BankAccounts.Add(account);
                return Ok(account);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet("/api/bankaccount")]
        public IActionResult GetAll([FromQuery] BankAccountFilterDto filter)
        {
            try
            {
                var accounts = BankAccounts.Where(x =>
                    (string.IsNullOrEmpty(filter.AccountName) || x.AccountName.Contains(filter.AccountName)) &&
                    (string.IsNullOrEmpty(filter.AccountNumber) || x.AccountNumber.Contains(filter.AccountNumber))
                ).ToList();
                return Ok(accounts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet("/api/bankaccount/{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var account = BankAccounts.FirstOrDefault(x => x.Id == id);
                if (account == null)
                {
                    return NotFound();
                }
                return Ok(account);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPut("/api/bankaccount/{id}")]
        public IActionResult Update(int id, [FromBody] BankAccountDto a)
        {
            try
            {
                var existingAccount = BankAccounts.FirstOrDefault(x => x.Id == id);
                if (existingAccount == null)
                {
                    return NotFound();
                }
                existingAccount.AccountName = a.AccountName;
                existingAccount.AccountNumber = a.AccountNumber;
                existingAccount.Balance = a.Balance;

                return Ok("Bank account updated successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpDelete("/api/bankaccount/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var account = BankAccounts.FirstOrDefault(x => x.Id == id);
                if (account == null)
                {
                    return NotFound();
                }

                BankAccounts.Remove(account);
                return Ok("Bank account deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }

    public class BankAccountDto
    {
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
    }

    public class BankAccountFilterDto
    { 
        public string? AccountName { get; set; }
        public string? AccountNumber { get; set; }
    }

    public class BankAccount
    { 
        public int Id { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
    }

