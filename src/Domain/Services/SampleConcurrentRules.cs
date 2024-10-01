using Domain.Enum;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Concurrent;
using System.Linq.Expressions;

namespace Domain.Services
{
    public class SampleConcurrentRules : ISampleConcurrentRules
    {
        private readonly IProductRepository _productRepository;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public SampleConcurrentRules(
            IProductRepository productRepository,
            IServiceScopeFactory serviceScopeFactory
        )
        {
            _productRepository = productRepository;
            _serviceScopeFactory = serviceScopeFactory;
        }

        #region Rules skeleton

        public async Task<ConcurrentDictionary<ProductEnum, ConcurrentBag<string>>> ExecuteDigitalServiceOnlyRules(Product product)
        {
            var rulesToExecute = new List<ProductEnum>
            {
                ProductEnum.ProductRule1,
                ProductEnum.ProductRule2,
                ProductEnum.ProductRule3,
                ProductEnum.ProductRule4,
                ProductEnum.ProductRule5,
                ProductEnum.ProductRule6,
                ProductEnum.ProductRule7,
                ProductEnum.ProductRule8,
            };

            return await ExecuteRules(rulesToExecute, product);
        }

        public async Task<ConcurrentDictionary<ProductEnum, ConcurrentBag<string>>>ExecuteRules(
            List<ProductEnum> rulesToExecute, Product product)
        {
            var errorCodesTable = GenerateSampleCodestableErrorMessage();
            var errorDictionary = new ConcurrentDictionary<ProductEnum, ConcurrentBag<string>>();

            var tasks = rulesToExecute.Select(rule => Task.Run(async () => 
            {
                using (var scope = _serviceScopeFactory.CreateScope()) 
                {
                    await ExecuteIndividualRule(rule, product, errorCodesTable, errorDictionary, scope.ServiceProvider);
                }
            }));

            if (!tasks.Any()) throw new Exception("No rules are running");
            await Task.WhenAll(tasks);

            return errorDictionary;
        }

        private async Task ExecuteIndividualRule(ProductEnum rule, Product product, List<string> errorCodesTable, 
            ConcurrentDictionary<ProductEnum, ConcurrentBag<string>> errorDictionary, IServiceProvider serviceProvider)
        {
            try
            {
                await (rule switch
                {
                    ProductEnum.ProductRule1 => Rule1_ValidateNameOnProduct(product, errorCodesTable, errorDictionary, serviceProvider),
                    ProductEnum.ProductRule2 => Rule2_ValidateContactOnProduct(product, errorCodesTable, errorDictionary, serviceProvider),
                    ProductEnum.ProductRule3 => Rule3_ValidateEmailOnProduct(product, errorCodesTable, errorDictionary, serviceProvider),
                    ProductEnum.ProductRule4 => Rule4_ValidateTest4OnProduct(product, errorCodesTable, errorDictionary, serviceProvider),
                    ProductEnum.ProductRule5 => Rule5_ValidateTest5OnProduct(product, errorCodesTable, errorDictionary, serviceProvider),
                    ProductEnum.ProductRule6 => Rule6_ValidateTest6OnProduct(product, errorCodesTable, errorDictionary, serviceProvider),
                    ProductEnum.ProductRule7 => Rule7_ValidateTest7OnProduct(product, errorCodesTable, errorDictionary, serviceProvider),
                    ProductEnum.ProductRule8 => Rule8_ValidateTest8OnProduct(product, errorCodesTable, errorDictionary, serviceProvider),
                    _ => throw new InvalidOperationException($"Unsupported rule: {rule}")
                });
            }
            catch (Exception ex) 
            {
                throw new Exception($"ExecuteIndividualRule error on {rule.ToString()} {ex.Message}");
            }
        }

        #endregion

        private async Task Rule1_ValidateNameOnProduct(Product product, List<string> errorCodesTable, 
            ConcurrentDictionary<ProductEnum, ConcurrentBag<string>> errorDictionary, IServiceProvider serviceProvider)
        {
            try
            {
                var repository = serviceProvider.GetRequiredService<IProductRepository>();

                var sampleRepositoryCall = await repository.RetrieveProductAsync(x => 
                    x.Price > 1
                );

                var errorMessage = errorCodesTable.Skip(0).Take(1).ToList().FirstOrDefault();

                if (errorMessage is not null)
                {
                    AddOrUpdateErrorMessage(errorDictionary, ProductEnum.ProductRule1, errorMessage);
                }
            }
            catch (Exception ex) 
            {
                throw new Exception($"Exception occured on {ProductEnum.ProductRule1}: {ex.Message}");
            }
        }

        private async Task Rule2_ValidateContactOnProduct(Product product, List<string> errorCodesTable, 
            ConcurrentDictionary<ProductEnum, ConcurrentBag<string>> errorDictionary, IServiceProvider serviceProvider)
        {
            try
            {
                var repository = serviceProvider.GetRequiredService<IProductRepository>();

                var sampleRepositoryCall = await repository.RetrieveProductAsync(x =>
                    x.Price > 2
                );

                var errorMessage = errorCodesTable.Skip(1).Take(1).ToList().FirstOrDefault();

                if (errorMessage is not null)
                {
                    AddOrUpdateErrorMessage(errorDictionary, ProductEnum.ProductRule2, errorMessage);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception occured on {ProductEnum.ProductRule2}: {ex.Message}");
            }
        }


        private async Task Rule3_ValidateEmailOnProduct(Product product, List<string> errorCodesTable, 
            ConcurrentDictionary<ProductEnum, ConcurrentBag<string>> errorDictionary, IServiceProvider serviceProvider)
        {
            try
            {
                var repository = serviceProvider.GetRequiredService<IProductRepository>();

                var sampleRepositoryCall = await repository.RetrieveProductAsync(x =>
                    x.Price > 3
                );

                var errorMessage = errorCodesTable.Skip(2).Take(1).ToList().FirstOrDefault();

                if (errorMessage is not null)
                {
                    AddOrUpdateErrorMessage(errorDictionary, ProductEnum.ProductRule3, errorMessage);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception occured on {ProductEnum.ProductRule3}: {ex.Message}");
            }
        }

        private async Task Rule4_ValidateTest4OnProduct(Product product, List<string> errorCodesTable, 
            ConcurrentDictionary<ProductEnum, ConcurrentBag<string>> errorDictionary, IServiceProvider serviceProvider)
        {
            try
            {
                var repository = serviceProvider.GetRequiredService<IProductRepository>();

                var sampleRepositoryCall = await repository.RetrieveProductAsync(x =>
                    x.Price > 4
                );

                var errorMessage = errorCodesTable.Skip(3).Take(1).ToList().FirstOrDefault();

                if (errorMessage is not null)
                {
                    AddOrUpdateErrorMessage(errorDictionary, ProductEnum.ProductRule4, errorMessage);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception occured on {ProductEnum.ProductRule4}: {ex.Message}");
            }
        }

        private async Task Rule5_ValidateTest5OnProduct(Product product, List<string> errorCodesTable, 
            ConcurrentDictionary<ProductEnum, ConcurrentBag<string>> errorDictionary, IServiceProvider serviceProvider)
        {
            try
            {
                var repository = serviceProvider.GetRequiredService<IProductRepository>();

                var sampleRepositoryCall = await repository.RetrieveProductAsync(x =>
                    x.Price > 5
                );

                var errorMessage = errorCodesTable.Skip(4).Take(1).ToList().FirstOrDefault();

                if (errorMessage is not null)
                {
                    AddOrUpdateErrorMessage(errorDictionary, ProductEnum.ProductRule5, errorMessage);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception occured on {ProductEnum.ProductRule5}: {ex.Message}");
            }
        }

        private async Task Rule6_ValidateTest6OnProduct(Product product, List<string> errorCodesTable, 
            ConcurrentDictionary<ProductEnum, ConcurrentBag<string>> errorDictionary, IServiceProvider serviceProvider)
        {
            try
            {
                var repository = serviceProvider.GetRequiredService<IProductRepository>();

                var sampleRepositoryCall = await repository.RetrieveProductAsync(x =>
                    x.Price > 6
                );

                var errorMessage = errorCodesTable.Skip(5).Take(1).ToList().FirstOrDefault();

                if (errorMessage is not null)
                {
                    AddOrUpdateErrorMessage(errorDictionary, ProductEnum.ProductRule6, errorMessage);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception occured on {ProductEnum.ProductRule6}: {ex.Message}");
            }
        }

        private async Task Rule7_ValidateTest7OnProduct(Product product, List<string> errorCodesTable, 
            ConcurrentDictionary<ProductEnum, ConcurrentBag<string>> errorDictionary, IServiceProvider serviceProvider)
        {
            try
            {
                var repository = serviceProvider.GetRequiredService<IProductRepository>();

                var sampleRepositoryCall = await repository.RetrieveProductAsync(x =>
                    x.Price > 7
                );

                var errorMessage = errorCodesTable.Skip(6).Take(1).ToList().FirstOrDefault();

                if (errorMessage is not null)
                {
                    AddOrUpdateErrorMessage(errorDictionary, ProductEnum.ProductRule7, errorMessage);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception occured on {ProductEnum.ProductRule7}: {ex.Message}");
            }
        }

        private async Task Rule8_ValidateTest8OnProduct(Product product, List<string> errorCodesTable, 
            ConcurrentDictionary<ProductEnum, ConcurrentBag<string>> errorDictionary, IServiceProvider serviceProvider)
        {
            try
            {
                var repository = serviceProvider.GetRequiredService<IProductRepository>();

                var sampleRepositoryCall = await repository.RetrieveProductAsync(x =>
                    x.Price > 8
                );

                var errorMessage = errorCodesTable.Skip(7).Take(1).ToList().FirstOrDefault();

                if (errorMessage is not null)
                {
                    AddOrUpdateErrorMessage(errorDictionary, ProductEnum.ProductRule8, errorMessage);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception occured on {ProductEnum.ProductRule8}: {ex.Message}");
            }
        }


        private List<string> GenerateSampleCodestableErrorMessage()
        {
            // imagine a list of objects, but instead we just use list of string for simplicity
            return new List<string>()
            {
                "error1",
                "error2",
                "error3",
                "error4",
                "error5",
                "error6",
                "error7",
                "error8"
            };
        }

        private void AddOrUpdateErrorMessage(ConcurrentDictionary<ProductEnum, ConcurrentBag<string>> errorDictionary,
            ProductEnum rule, string errorMessage)
        {
            errorDictionary.AddOrUpdate(
                key: rule,
                addValue: new ConcurrentBag<string> { errorMessage },
                updateValueFactory: (key, existingBag) =>
                {
                    existingBag.Add(errorMessage);
                    return existingBag;
                }
            );
        }
    }
}
