﻿using System;
using System.Windows.Input;

/* wechat:   InnerGeeker 香辣恐龙蛋
 * bilibili: 香辣恐龙蛋
 * https://space.bilibili.com/14343016
 */

namespace LoongEgg.ViewModelBase
{
    /// <summary>
    ///     泛型的Relay command, 避免实际的<see cref="Execute(object)"/>需要执行一次类型转换
    ///     The base command run an action
    /// </summary>
    public class RelayCommand<T> : ICommand
    {

        /*--------------------------  Public Methods  --------------------------*/
        /// <summary>
        ///     The event raised when <see cref="CanExecute(object)"/> changed
        /// </summary>
        public event EventHandler CanExecuteChanged = (s, e) => { };

        /*---------------------------  Constructor  ---------------------------*/
        /// <summary>
        ///     command的基类
        ///     Constructor of <see cref="RelayCommand"/>
        /// </summary>
        ///     <param name="execute">
        ///         执行命令的实际方法
        ///     </param>
        ///     <param name="canExecute">
        ///         判断命令是否可以执行的方法
        ///     </param>
        public RelayCommand(Action<T> execute, Func<T, bool> canExecute = null)
        {
            _Execute = execute;
            _CanExecute = canExecute;
        }

        /// <summary>
        ///     判断是否可以执行命令的方法
        ///     Check if this command action can execute
        /// NOTE: 
        ///     If the can execute function not set, will always return true;
        /// </summary>
        ///     <param name="parameter">
        ///     </param>
        /// <returns>
        /// </returns>
        public bool CanExecute(object parameter)
            => _CanExecute == null ? true : _CanExecute((T)parameter);
        private readonly Func<T, bool> _CanExecute = null;

        //*--------------------------  Public Methods  --------------------------*/
        /// <summary>
        ///     实际执行命令的方法
        ///     The action to execute this command
        /// </summary>
        ///     <param name="parameter">
        ///         Command parameter 传过来的参数
        ///     </param>
        public void Execute(object parameter)
            => _Execute((T)parameter);
        private readonly Action<T> _Execute;

    }
}
