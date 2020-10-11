﻿/* 
 * This file is part of the MyOhmSessions distribution (https://github.com/GroovemanAndCo/MyOhmStudio).
 * Copyright (c) 2020 Fabien (https://github.com/fab672000)
 * 
 * This program is free software: you can redistribute it and/or modify  
 * it under the terms of the GNU General Public License as published by  
 * the Free Software Foundation, version 3.
 *
 * This program is distributed in the hope that it will be useful, but 
 * WITHOUT ANY WARRANTY; without even the implied warranty of 
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU 
 * General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License 
 * along with this program. If not, see <http://www.gnu.org/licenses/>.
 */

namespace OhmstudioManager.ViewModel
{
    /// <summary>
    /// Simple library independent abstraction enum for selecting an application color scheme
    /// </summary>
    public enum AppColorScheme
    {
        Dark,
        Light
    };

    /// <summary>
    /// Simple library independent interface for selecting an application color scheme
    /// </summary>
    public interface IAppColorSchemeSetter
    {
        void SetColorScheme(AppColorScheme colorScheme);

    }
}