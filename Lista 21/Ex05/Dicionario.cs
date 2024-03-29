﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05
{
    class Dicionario<K, V>
    {
        private List<K> chaves = new List<K>();
        private List<V> valores = new List<V>();
        public List<K> Chaves { get => chaves; }
        public List<V> Valores { get => valores; }
        public int Count
        {
            get
            {
                return valores.Count;
            }
        }
        public V this[K chave]
        {
            set
            {
                if (chaves.Contains(chave)) valores[chaves.IndexOf(chave)] = value;
                else
                {
                    chaves.Add(chave);
                    valores.Add(value);
                }
            }
            get
            {
                int p = chaves.IndexOf(chave);
                if (p == -1) throw new InvalidOperationException();
                else return valores[p];
            }
        }
        public void Add(K chave, V valor)
        {
            if (chave == null) throw new InvalidOperationException();
            if (chaves.Contains(chave)) throw new InvalidOperationException();
            else
            {
                chaves.Add(chave);
                valores.Add(valor);
            }
        }
        public void Clear()
        {
            chaves.Clear();
            valores.Clear();
        }
        public bool Remove(K chave)
        {
            if (chaves.IndexOf(chave) == -1) return false;
            else
            {
                int indice = chaves.IndexOf(chave);
                chaves.RemoveAt(indice);
                valores.RemoveAt(indice);
                return true;
            }
        }
        public bool Contains(K chave) => chaves.Contains(chave);
    }
}
