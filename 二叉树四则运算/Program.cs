using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace 二叉树四则运算
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入四则运算表达式:");
            string read = Console.ReadLine();
            //去除运算字符串中的空格,将括号统一为英文格式的
            read.Replace(" ", "").Replace("（", "(").Replace("）",")");
            Regex.Replace()
        }
    }
    /// <summary>
    /// 运算树
    /// </summary>
    public class OperationTree<T>
    {
        /// <summary>
        /// 头结点
        /// </summary>
        public T data { get; set; }
        /// <summary>
        /// 左节点
        /// </summary>
        public OperationTree<T> LChild { get; set; }
        /// <summary>
        /// 右结点
        /// </summary>
        public OperationTree<T> RChild { get; set; }
    }
    /// <summary>
    /// 节点
    /// </summary>
    public class Node
    {
        /// <summary>
        /// 节点值
        /// </summary>
        public object value { get; set; }
        /// <summary>
        /// 节点类型
        /// </summary>
        public NodeType Nodetype { get; set; }
    }
    /// <summary>
    /// 节点类型
    /// </summary>
    public enum NodeType
    {
        /// <summary>
        /// 数字
        /// </summary>
        Number = 0,
        /// <summary>
        /// 运算符
        /// </summary>
        Operation = 1
    }
}
