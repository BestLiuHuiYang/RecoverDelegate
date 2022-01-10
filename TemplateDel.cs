using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecoverDelegate
{
    //创建一个商品
    class MyProduct
    {
        public string Pname { get; set; }
    }
    //商品放到盒子里面
    class MyBox
    {
        public MyProduct MyProduct { get; set; }
    }

    //创建一个工厂，用来生产商品并放入盒子里
    class ProductFactory
    {
        //该方法就属于模板方法
        public MyBox MakeProductIntoBox(Func<MyProduct> FuncProduct)
        {
            //将盒子进行实例化
            MyBox box=new MyBox();
            //制作产品
            MyProduct pro=FuncProduct();
            //把产品装入盒子
            box.MyProduct = pro;
            return box;
        }
    }
    //使用模板方法把前面的逻辑写好，前面三个类就不用动了，只需要一直更改MakeProduct就可以了
    class MakeProduct
    {
        //商品--面条
        public MyProduct Noodles()
        {
            MyProduct mp=new MyProduct();
            mp.Pname = "Noodles";
            return mp;
        }
        //商品--玩具
        public MyProduct Toys()
        {
            MyProduct mp=new MyProduct();
            mp.Pname = "Toys";
            return mp;
        }
    }


}
