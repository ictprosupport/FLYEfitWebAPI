/*
 * Flyefit API
 *
 * This is FLYEfit's API for access it's internal member database
 *
 * OpenAPI spec version: 0.4.0
 * Contact: api@flyefit.ie
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Models
{

    /// <summary>
    /// 1:Super User;2:Administrator;3:Personal Trainer;4:Member;5:Manager;6:Agent;7:None
    /// </summary>
    [DataContract]
    public partial class Role :  IEquatable<Role>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="Role" /> class.
        /// </summary>
        /// <param name="RoleId">RoleId.</param>
        /// <param name="_Role">_Role.</param>
        public Role(int? RoleId = default(int?), string _Role = default(string))
        {
            this.RoleId = RoleId;
            this._Role = _Role;
            
        }

        /// <summary>
        /// Gets or Sets RoleId
        /// </summary>
        [DataMember(Name="roleId")]
        public int? RoleId { get; set; }
        /// <summary>
        /// Gets or Sets _Role
        /// </summary>
        [DataMember(Name="role")]
        public string _Role { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Role {\n");
            sb.Append("  RoleId: ").Append(RoleId).Append("\n");
            sb.Append("  _Role: ").Append(_Role).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Role)obj);
        }

        /// <summary>
        /// Returns true if Role instances are equal
        /// </summary>
        /// <param name="other">Instance of Role to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Role other)
        {

            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    this.RoleId == other.RoleId ||
                    this.RoleId != null &&
                    this.RoleId.Equals(other.RoleId)
                ) && 
                (
                    this._Role == other._Role ||
                    this._Role != null &&
                    this._Role.Equals(other._Role)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            // credit: http://stackoverflow.com/a/263416/677735
            unchecked // Overflow is fine, just wrap
            {
                int hash = 41;
                // Suitable nullity checks etc, of course :)
                    if (this.RoleId != null)
                    hash = hash * 59 + this.RoleId.GetHashCode();
                    if (this._Role != null)
                    hash = hash * 59 + this._Role.GetHashCode();
                return hash;
            }
        }

        #region Operators

        public static bool operator ==(Role left, Role right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Role left, Role right)
        {
            return !Equals(left, right);
        }

        #endregion Operators

    }
}
