﻿using System;
using System.Collections.Generic;
using System.Text;

namespace kasir.Model
{
    class Payment
    {
        OnPaymentChangedListener paymentListener;
        public Payment(OnPaymentChangedListener paymentListener)
        {

            this.paymentListener = paymentListener;
        }

        public void updateTotal(double subTotal, double promo)
        {

            double total = subTotal - promo;
            this.paymentListener.onPriceUpdated(subTotal, total, promo);

        }
    }
    interface OnPaymentChangedListener
    {
        void onPriceUpdated(double subtTotal, double total, double promo);
    }
}
