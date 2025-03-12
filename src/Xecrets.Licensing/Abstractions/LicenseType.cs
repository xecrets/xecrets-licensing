﻿#region Copyright and License

/*
 * Xecrets Licensing - Copyright © 2022-2025, Svante Seleborg, All Rights Reserved.
 *
 * This code file is part of Xecrets Licensing
 *
 * Xecrets Licensing is free software: you can redistribute it and/or modify it under the terms of the GNU General
 * Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any
 * later version.
 *
 * Xecrets Licensing is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the
 * implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more
 * details.
 *
 * You should have received a copy of the GNU General Public License along with Xecrets Licensing.  If not, see
 * <https://www.gnu.org/licenses/>.
 *
 * The source repository can be found at https://github.com/xecrets/xecrets-licensing please go there for more
 * information, suggestions and contributions. You may also visit https://www.axantum.com for more information about the
 * author, or submit support requests at https://www.axantum.com/support .
*/

#endregion Copyright and License

namespace Xecrets.Licensing.Abstractions;

/// <summary>
/// Different types of license that may be issued.
/// </summary>
public enum LicenseType
{
    /// <summary>
    /// Unknown or no license type
    /// </summary>
    None = 0,
    /// <summary>
    /// A complimentary free premium license. Coded as "free" in the license.
    /// </summary>
    Free,
    /// <summary>
    /// A free premium trial license, gained without entering any payment details or starting
    /// a subscription. Coded as "test" in the license.
    /// </summary>
    FreeTest,
    /// <summary>
    /// A payment premium trial license, a free period before a credit card is charged.
    /// Coded as "trial" in the license.
    /// </summary>
    Trial,
    /// <summary>
    /// A paid premium license. Coded as "paid" in the license.
    /// </summary>
    Paid,
}
