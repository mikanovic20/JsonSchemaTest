using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JsonSchemaCSharp {

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Student
    /// </summary>
    /// <remarks>
    /// For generating schema, and reading contents
    /// </remarks>
    public class Student {

        #region Properties

        [Required]
        [RegularExpression( @"^[A-Z][0-9]{7}?$" )]
        [JsonProperty( Order = 1, Required = Required.Always )]
        public string Id { get; set; }

        [Required]
        [StringLength( 20 )]
        [JsonProperty( Order = 2, Required = Required.Always )]
        public string Name { get; set; }

        [Required]
        [DataType( DataType.DateTime )]
        [JsonProperty( Order = 3 )]
        public DateTime Birth { get; set; }

        [Required]
        [EnumDataType( typeof( BloodType ) )]
        [JsonProperty( Order = 4 )]
        [JsonConverter( typeof( BloodTypeEnumConverter ) )]
        public BloodType BloodType { get; set; }

        #endregion

        #region Constructors

        public Student() { }

        #endregion

        #region Public Methods - Overrides

        public override string ToString() {

            return string.Format( @"ID        : {0}{4}" +
                                  @"Name      : {1}{4}" +
                                  @"Birth     : {2:yyyy/MM/dd}{4}" +
                                  @"BloodType : {3}{4}",
                                  Id, Name, Birth, BloodType.ToString(), Environment.NewLine );
        }

        #endregion
    }

    /// <summary>
    /// BloodType
    /// </summary>
    public enum BloodType {

        Undefined,
        A,
        B,
        O,
        AB,
    }

    /// <summary>
    /// StringEnumConverter for BloodType
    /// </summary>
    /// <remarks>
    /// If value is invalid on deserializing, to use default value.
    /// Overrides only ReadJson method.
    /// </remarks>
    public class BloodTypeEnumConverter : StringEnumConverter {

        public override object ReadJson(
            JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer ) {

            try {
                return base.ReadJson( reader, objectType, existingValue, serializer );
            }
            catch ( JsonSerializationException ) {
                return BloodType.Undefined;
            }
        }
    }
}
