using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;

namespace Services.Core.Application
{
    public class SwaggerEnumDescricao : IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
        {
            foreach (KeyValuePair<string, Schema> schemaDictionaryItem in swaggerDoc.Definitions)
            {
                Schema schema = schemaDictionaryItem.Value;

                foreach (KeyValuePair<string, Schema> propertyDictionaryItem in schema.Properties)
                {
                    Schema property = propertyDictionaryItem.Value;

                    IList<object> propertyEnums = property.Enum;

                    if (propertyEnums != null && propertyEnums.Count > 0)
                    {
                        property.Description += Environment.NewLine + GetDescricaoEnum(propertyEnums);
                    }
                }
            }
        }

        private string GetDescricaoEnum(IList<object> enums)
        {
            List<string> enumDescriptions = new List<string>();

            foreach (object enumOption in enums)
            {
                enumDescriptions.Add(string.Format("{0} = {1}", (int)enumOption, Enum.GetName(enumOption.GetType(), enumOption)));
            }

            return string.Join(", ", enumDescriptions.ToArray());
        }
    }
}
