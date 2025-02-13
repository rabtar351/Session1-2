using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models;

/// <summary>
/// Список дней исключений в производственном календаре
/// </summary>
[Table("WorkingCalendar")]
public partial class WorkingCalendar
{
    /// <summary>
    /// Идентификатор строки
    /// </summary>
    [Key]
    public long Id { get; set; }

    /// <summary>
    /// День-исключение
    /// </summary>
    public DateOnly ExceptionDate { get; set; }

    /// <summary>
    /// 0 - будний день, но законодательно принят выходным
    /// </summary>
    public bool IsWorkingDay { get; set; }
}
