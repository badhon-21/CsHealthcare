using System;
using System.ComponentModel.DataAnnotations;

namespace CsHealthcare.DataAccess.Core
{
    public abstract class BaseEntity
    {
        private int? _requestedHashCode;

        [Key]
        public string Id { get; set; }

        public bool IsTransient()
        {
            return Id == null;
        }

        #region Overrides Methods

        /// <summary>
        /// <see cref="M:System.Object.Equals"/>
        /// </summary>
        /// <param name="obj"><see cref="M:System.Object.Equals"/></param>
        /// <returns><see cref="M:System.Object.Equals"/></returns>
        public override bool Equals(object obj)
        {
            var entity = obj as BaseEntity;
            if (entity == null)
                return false;

            if (Object.ReferenceEquals(this, obj))
                return true;

            if (GetRealObjectType(this) != GetRealObjectType(obj))
                return false;

            if (IsTransient())
                return false;

            return entity.Id == Id;

        }

        /// <summary>
        /// <see cref="M:System.Object.GetHashCode"/>
        /// </summary>
        /// <returns><see cref="M:System.Object.GetHashCode"/></returns>
        public override int GetHashCode()
        {
            if (!IsTransient())
            {
                if (!_requestedHashCode.HasValue)
                    _requestedHashCode = Id.GetHashCode() ^ 31; // XOR for random distribution (http://blogs.msdn.com/b/ericlippert/archive/2011/02/28/guidelines-and-rules-for-gethashcode.aspx)

                return _requestedHashCode.Value;
            }
            else
                return base.GetHashCode();
        }

        public static bool operator ==(BaseEntity left, BaseEntity right)
        {
            if (Object.Equals(left, null))
                return (Object.Equals(right, null)) ? true : false;
            else
                return left.Equals(right);
        }

        public static bool operator !=(BaseEntity left, BaseEntity right)
        {
            return !(left == right);
        }

        #endregion

        private Type GetRealObjectType(object obj)
        {
            var retVal = obj.GetType();
            //because can be compared two object with same id and 'types' but one of it is EF dynamic proxy type)
            if (retVal.BaseType != null && retVal.Namespace == "System.Data.Entity.DynamicProxies")
            {
                retVal = retVal.BaseType;
            }
            return retVal;
        }
    }
}
