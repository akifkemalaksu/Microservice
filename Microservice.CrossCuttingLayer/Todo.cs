using System;

namespace Microservice.CrossCuttingLayer
{
    public class Todo
    {
        public string Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public string TaskDescription { get; set; }
        public bool IsCompleted { get; set; }
    }
}