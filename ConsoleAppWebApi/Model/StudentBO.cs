using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class StudentBO {
    /// <summary>
    /// Gets or Sets Id
    /// </summary>
    [DataMember(Name="id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "id")]
    public int? Id { get; set; }

    /// <summary>
    /// Gets or Sets FirstName
    /// </summary>
    [DataMember(Name="firstName", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "firstName")]
    public string FirstName { get; set; }

    /// <summary>
    /// Gets or Sets LastName
    /// </summary>
    [DataMember(Name="lastName", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "lastName")]
    public string LastName { get; set; }

    /// <summary>
    /// Gets or Sets RollNo
    /// </summary>
    [DataMember(Name="rollNo", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "rollNo")]
    public int? RollNo { get; set; }

    /// <summary>
    /// Gets or Sets Marks
    /// </summary>
    [DataMember(Name="marks", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "marks")]
    public int? Marks { get; set; }

    /// <summary>
    /// Gets or Sets BranchId
    /// </summary>
    [DataMember(Name="branchId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "branchId")]
    public int? BranchId { get; set; }

    /// <summary>
    /// Gets or Sets BranchName
    /// </summary>
    [DataMember(Name="branchName", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "branchName")]
    public string BranchName { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class StudentBO {\n");
      sb.Append("  Id: ").Append(Id).Append("\n");
      sb.Append("  FirstName: ").Append(FirstName).Append("\n");
      sb.Append("  LastName: ").Append(LastName).Append("\n");
      sb.Append("  RollNo: ").Append(RollNo).Append("\n");
      sb.Append("  Marks: ").Append(Marks).Append("\n");
      sb.Append("  BranchId: ").Append(BranchId).Append("\n");
      sb.Append("  BranchName: ").Append(BranchName).Append("\n");
      sb.Append("}\n");
      return sb.ToString();
    }

    /// <summary>
    /// Get the JSON string presentation of the object
    /// </summary>
    /// <returns>JSON string presentation of the object</returns>
    public string ToJson() {
      return JsonConvert.SerializeObject(this, Formatting.Indented);
    }

}
}
