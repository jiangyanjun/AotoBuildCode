using System;
using System.Collections.Generic;
[USING]

namespace [NAMESPACE]
{

	/// <summary>
    /// [TYPE] business class
    /// </summary>
    public class [TYPE]Business
    {
       
         /// <summary>
        /// 
        /// </summary>
		/// <returns></returns>
        public List<[TYPE]> List()
        {
            return new [DAO].List();
        }

         /// <summary>
        /// 
        /// </summary>
		/// <param name="[OBJECT]"></param>
		/// <returns></returns>
        public [TYPE] Insert([TYPE] [OBJECT])
        {
			return new [DAO].Insert([OBJECT]);
        }

         /// <summary>
        /// 
        /// </summary>
        /// <param name="[OBJECT]"></param>
		/// <returns></returns>
        public [TYPE] Edit([TYPE] [OBJECT])
        {
            return new [DAO].Edit([OBJECT]);
        }

         /// <summary>
        /// 
        /// </summary>
        /// <param name="[OBJECT]"></param>
        /// <returns></returns>
        public void Delete([TYPE] [OBJECT])
        {
            new [DAO].Delete([OBJECT]);
        }
	}
}