using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Sale
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Number { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;

    public int CustomerId { get; set; }
    public virtual Customer Customer { get; set; }

    public decimal TotalValue { get; set; } = 0;

    public int BranchId { get; set; }
    public virtual Branch Branch { get; set; }

    public virtual ICollection<SaleItem> Items { get; set; }

    public SaleStatus Status { get; set; }

    public void Activate()
    {
        Status = SaleStatus.Active;
    }

    public void Cancel()
    {
        Status = SaleStatus.Cancelled;
    }

    public void CalculateValues()
    {
        CalculateDiscounts();

        TotalValue = Items.Sum(x => x.TotalPrice);
    }

    private void CalculateDiscounts()
    {
        foreach (var item in Items)
        {
            item.TotalPrice = item.UnitaryPrice * item.Quantity;

            if (item.Quantity < 4)
            {
                item.Discount = 0;
            }
            else if (item.Quantity < 10)
            {
                item.Discount = Math.Round(item.TotalPrice * 0.1M, 2);
                item.TotalPrice -= item.Discount;
            }
            else if (item.Quantity <= 20)
            {
                item.Discount = Math.Round(item.TotalPrice * 0.2M, 2);
                item.TotalPrice -= item.Discount;
            }
        }
    }   

    public ValidationResultDetail Validate()
    {
        var validator = new SaleValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }

    public Sale() { }

    public Sale(int number, DateTime date, int customerId, Customer customer, decimal totalValue, int branchId, Branch branch, ICollection<SaleItem> items, SaleStatus status)
    {
        Number = number;
        Date = date;
        CustomerId = customerId;
        Customer = customer;
        TotalValue = totalValue;
        BranchId = branchId;
        Branch = branch;
        Items = items;
        Status = status;
    }
}
