﻿using examination_system.DB;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Student_Subject
{
    [Key]
    [Column(Order = 0)]
    public int StudentId { get; set; }
    public Student Student { get; set; }

    [Key]
    [Column(Order = 1)]
    public int SubjectId { get; set; }
    public Subject Subject { get; set; }
}