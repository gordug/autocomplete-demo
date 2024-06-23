using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Autocomplete.Demo.Data.DeviceUser;

[Table("device_users")]
public class DeviceUserModel
{
    public DeviceUserModel()
    {
    }
    
    public DeviceUserModel(string forename, string surname, string keypadId, string cardId, string enrolmentId, string pin)
    {
        Forename = forename;
        Surname = surname;
        KeypadId = keypadId;
        CardId = cardId;
        EnrolmentId = enrolmentId;
        Pin = pin;
    }

    [Required, MaxLength(50)]
    public string Forename { get; init; } = string.Empty;
    [Required, MaxLength(50)]
    public string Surname { get; init; } = string.Empty;
    [MaxLength(10)]
    public string KeypadId { get; init; } = string.Empty;
    [MaxLength(10)]
    public string CardId { get; init; } = string.Empty;
    [MaxLength(10)]
    public string EnrolmentId { get; init; } = string.Empty;
    [MaxLength(10)]
    public string Pin { get; init; } = string.Empty;

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id
    {
        get; init;
    }
}
