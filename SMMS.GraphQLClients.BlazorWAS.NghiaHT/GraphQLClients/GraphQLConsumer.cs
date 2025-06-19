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
            var result = response?.Data?.requestNghiaHt;

            return result;
        }
        catch (Exception ex)
        {
            return new RequestNghiaHt();
        }
    }
}
