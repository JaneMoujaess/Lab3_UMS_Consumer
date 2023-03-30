using System;
using System.Collections.Generic;

namespace NotificationCenter_Lab3_MicroservicesPractice.Models;

public partial class Notification
{
    public long Id { get; set; }

    public long TeacherId { get; set; }

    public long StudentId { get; set; }

    public long CourseId { get; set; }
}
