using UnityEngine;
using System.Collections;
using System;
public class YığınlamaSıralaması<T> where T :IYığınItem<T>{
    T[] itemler;
    int şuankiItemSayısı;
    public YığınlamaSıralaması(int makYığınBüyüklüğü)
    {
        itemler = new T[makYığınBüyüklüğü];
    }
    public void Ekle(T item)
    {
        item.YığınSıra = şuankiItemSayısı;
        itemler[şuankiItemSayısı] = item;
        Sırala(item);
        şuankiItemSayısı++;
    }
    public T İlkiniSil()
    {
        T ilkItem = itemler[0];
        şuankiItemSayısı--;
        itemler[0] = itemler[şuankiItemSayısı];
        itemler[0].YığınSıra = 0;
        GeriSırala(itemler[0]);
        return ilkItem;
    }
    public void ItemGüncelle(T item)
    {
        Sırala(item);
    }
    public int Adet
    {
        get
        {
            return şuankiItemSayısı;
        }
    }
    public bool Sahip(T item)
    {
        return Equals(itemler[item.YığınSıra], item);
    }
    void GeriSırala(T item)
    {
        while (true)
        {
            int altObjeSolSıra = item.YığınSıra * 2 + 1;
            int altObjeSağSıra = item.YığınSıra * 2 + 2;
            int sıraDeğiştir = 0;
            if (altObjeSolSıra<şuankiItemSayısı)
            {
                sıraDeğiştir = altObjeSolSıra;
                if (altObjeSağSıra<şuankiItemSayısı)
                {
                    if (itemler[altObjeSolSıra].CompareTo(itemler[altObjeSağSıra])<0)
                    {
                        sıraDeğiştir = altObjeSağSıra;
                    }
                }
                if (item.CompareTo(itemler[sıraDeğiştir])<0)
                {
                    Değiştir(item, itemler[sıraDeğiştir]);
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }
        }
    }
    void Sırala(T item)
    {
        int kaynakSırası = (int)((item.YığınSıra - 1) * 0.5f);
        while (true)
        {
            T kaynakItem = itemler[kaynakSırası];
            if (item.CompareTo(kaynakItem)>0)
            {
                Değiştir(item, kaynakItem);
            }
            else
            {
                break;
            }
            kaynakSırası= (int)((item.YığınSıra - 1) * 0.5f);
        }
    }
    void Değiştir(T itemA,T itemB)
    {
        itemler[itemA.YığınSıra] = itemB;
        itemler[itemB.YığınSıra] = itemA;
        int geçSıra = itemA.YığınSıra;
        itemA.YığınSıra = itemB.YığınSıra;
        itemB.YığınSıra = geçSıra;
    }
}
public interface IYığınItem<T>: IComparable<T>
{
    int YığınSıra
    {
        get;
        set;
    }
}
