namespace Store.Repo.Specifications.Product
{
    public class ProductWithSpecifications :BaseSpecification<Store.Data.Entities.Product>
    {
        public ProductWithSpecifications(ProductSpecification specs) 
            : base
            (Product => (!specs.BrandId.HasValue || Product.BrandId == specs.BrandId.Value)
                        &&(!specs.TypeId.HasValue || Product.TypeId == specs.TypeId.Value)
                        && (string.IsNullOrEmpty(specs.Search) || Product.Name.Trim().ToLower().Contains(specs.Search))
            ) 

        {
            AddInclude(x => x.Brand);
            AddInclude(x => x.Type);
            AddOrderBy(x => x.Name);
            ApplyPagination(specs.PageSize * (specs.PageIndex - 1), specs.PageSize);



            if (!string.IsNullOrEmpty(specs.Sort))
            {
                switch (specs.Sort)
                {
                    case "Name":
                        AddOrderBy(x => x.Name);
                        break;

                    case "Id":
                        AddOrderBy(x => x.Id);
                        break;

                    default:
                        AddOrderBy(x => x.Id); // Default sorting
                        break;
                }
            }
            else
            {
                AddOrderBy(x => x.Id); // Default sorting if specs.Sort is null or empty
            }


        }


        public ProductWithSpecifications(int? id) : base (product => product.Id == id)
        {
            AddInclude(x => x.Brand);
            AddInclude(x => x.Type);
            AddOrderBy(x => x.Name);
        }



    }
}
