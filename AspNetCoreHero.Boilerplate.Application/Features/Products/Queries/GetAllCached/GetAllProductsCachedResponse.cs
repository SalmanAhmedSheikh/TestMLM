﻿namespace AspNetCoreHero.Boilerplate.Application.Features.Products.Queries.GetAllCached
{
    public class GetAllProductsCachedResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Barcode { get; set; }
        public byte[] Image { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }
        public Guid BrandId { get; set; }
    }
}