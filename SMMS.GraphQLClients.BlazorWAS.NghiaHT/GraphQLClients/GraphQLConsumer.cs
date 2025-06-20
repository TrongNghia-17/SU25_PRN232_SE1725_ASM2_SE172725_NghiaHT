using GraphQL;
using GraphQL.Client.Abstractions;
using SMMS.GraphQLClients.BlazorWAS.NghiaHT.Models;

namespace SMMS.GraphQLClients.BlazorWAS.NghiaHT.GraphQLClients;

public class GraphQLConsumer
{
    private readonly IGraphQLClient _graphQLClient;
    public GraphQLConsumer(IGraphQLClient graphQLClient) => _graphQLClient = graphQLClient;

    public async Task<List<RequestNghiaHt>> GetRequestNghiaHts()
    {
        try
        {
            var query = @"query RequestNghiaHts {
                            requestNghiaHt{
                              requestNghiaHtid
                              medicationName
                              dosage
                              frequency
                              reason
                              instruction
                              quantity
                              startDate
                              createdDate
                              isApproved
                              medicationCategoryQuanTn{
                                categoryName
                              }
                            }
                         }";

            var response = await _graphQLClient.SendQueryAsync<RequestNghiaHtsGraphQLResponse>(query);
            if (response.Errors != null && response.Errors.Any())
            {
                Console.WriteLine("GraphQL Errors: " + string.Join(", ", response.Errors.Select(e => e.Message)));
                return new List<RequestNghiaHt>();
            }

            var result = response?.Data?.requestNghiaHt ?? new List<RequestNghiaHt>();
            return result;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in GetRequestNghiaHts: {ex.Message}");
            return new List<RequestNghiaHt>();

        }
    }

    public async Task<RequestNghiaHt> GetRequestNghiaHt(int id)
    {
        try
        {
            #region GraphQL Request

            var graphQLRequest = new GraphQLRequest
            {
                Query = @"query RequestNghiaHtById($id: Int!) {
                        requestNghiaHtById(id: $id) {
                          requestNghiaHtid
                          medicationName
                          dosage
                          frequency
                          reason
                          instruction
                          quantity
                          startDate
                          createdDate
                          isApproved
                          medicationCategoryQuanTn {
                            categoryName
                          }
                        }
                     }",
                Variables = new { id = id }
                //,OperationName = "CategoryBankAccounts"
            };
            #endregion


            var response = await _graphQLClient.SendQueryAsync<RequestNghiaHtGraphQLResponse>(graphQLRequest);
            var result = response?.Data?.requestNghiaHtById;

            return result;
        }
        catch (Exception ex)
        {
            return new RequestNghiaHt();
        }
    }

    public async Task<List<MedicationCategoryQuanTn>> GetMedicationCategories()
    {
        try
        {
            var query = @"query MedicationCategories {
                            medicationCategoryQuanTns {
                                medicationCategoryQuanTnid
                                categoryName
                            }
                         }";

            var response = await _graphQLClient.SendQueryAsync<MedicationCategoriesGraphQLResponse>(query);
            if (response.Errors != null && response.Errors.Any())
            {
                Console.WriteLine("GraphQL Errors: " + string.Join(", ", response.Errors.Select(e => e.Message)));
                return new List<MedicationCategoryQuanTn>();
            }

            var result = response?.Data?.medicationCategoryQuanTns ?? new List<MedicationCategoryQuanTn>();
            return result;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in GetMedicationCategories: {ex.Message}");
            return new List<MedicationCategoryQuanTn>();
        }
    }

    public async Task<int> CreateRequestNghiaHt(RequestNghiaHt request)
    {
        try
        {
            var mutation = new GraphQLRequest
            {
                Query = @"mutation CreateRequestNghiaHt($requestNghiaHtInput: CreateRequestNghiaHtInput!) {
                            createRequestNghiaHt(requestNghiaHtInput: $requestNghiaHtInput)
                         }",
                Variables = new
                {
                    requestNghiaHtInput = new
                    {
                        medicationName = request.MedicationName,
                        dosage = request.Dosage,
                        frequency = request.Frequency,
                        reason = request.Reason,
                        instruction = request.Instruction,
                        quantity = request.Quantity,
                        startDate = request.StartDate?.ToString("yyyy-MM-ddTHH:mm:ssZ"),
                        createdDate = request.CreatedDate?.ToString("yyyy-MM-ddTHH:mm:ssZ"),
                        isApproved = request.IsApproved,
                        medicationCategoryQuanTnid = request.MedicationCategoryQuanTnid
                    }
                }
            };

            var response = await _graphQLClient.SendMutationAsync<CreateRequestNghiaHtResponse>(mutation);
            if (response.Errors != null && response.Errors.Any())
            {
                Console.WriteLine("GraphQL Errors: " + string.Join(", ", response.Errors.Select(e => e.Message)));
                return 0;
            }

            return response.Data.createRequestNghiaHt;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in CreateRequestNghiaHt: {ex.Message}");
            return 0;
        }
    }

    public async Task<bool> DeleteRequestNghiaHt(int id)
    {
        try
        {
            var mutation = new GraphQLRequest
            {
                Query = @"mutation DeleteRequestNghiaHt($id: Int!) {
                        deleteRequestNghiaHt(id: $id)
                     }",
                Variables = new { id = id }
            };

            var response = await _graphQLClient.SendMutationAsync<DeleteRequestNghiaHtResponse>(mutation);
            if (response.Errors != null && response.Errors.Any())
            {
                Console.WriteLine("GraphQL Errors: " + string.Join(", ", response.Errors.Select(e => e.Message)));
                return false;
            }

            return response.Data.deleteRequestNghiaHt;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in DeleteRequestNghiaHt: {ex.Message}");
            return false;
        }
    }
}

