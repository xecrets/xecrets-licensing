#region Coypright and License

/*
 * Xecrets Licensing - Copyright © 2022-2023, Svante Seleborg, All Rights Reserved.
 *
 * This code file is part of Xecrets Licensing
 * 
 * Unless explicitly licensed in writing, this source code is the sole property of Axantum Software AB,
 * and may not be copied, distributed, sold, modified or otherwise used in any way.
*/

#endregion Coypright and License

namespace Xecrets.Licensing.Abstractions
{
    /// <summary>
    /// A dependency locator
    /// </summary>
    public interface INewLocator
    {
        /// <summary>
        /// Locate an instance of the give type.
        /// </summary>
        /// <typeparam name="T">The type to find an instance for.</typeparam>
        /// <returns>An instance of the given type.</returns>
        T New<T>() where T : class;
    }
}
