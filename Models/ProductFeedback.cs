//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SampleAppDemo.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductFeedback
    {
        public int RatingID { get; set; }
        public string RatingType { get; set; }
        public string ProductReview { get; set; }
        public int ProductId { get; set; }
    
        public virtual ProductFeedback ProductFeedback1 { get; set; }
        public virtual ProductFeedback ProductFeedback2 { get; set; }
    }
}