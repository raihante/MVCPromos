using System;
using System.Collections.Generic;
using System.Text;

namespace Promos.Model
{
    class Payment
    {
        private double deliveryFee = 0;
        private double promo = 0;
        private double balance = 0;
        private OnPaymentChangedListener paymentCallback;

        public Payment(OnPaymentChangedListener paymentCallback)
        {
            this.paymentCallback = paymentCallback;
        }

        public void setBalance(double balance)
        {
            this.balance = balance;
        }

        public double getBalance()
        {
            return this.balance;
        }

        public void setDeliveryFee(double deliveryFee)
        {
            this.deliveryFee = deliveryFee;
        }
        public double getDeliveryFee()
        {
            return this.deliveryFee;
        }

        public double getPromo()
        {
            return this.promo;
        }

        public void setPromo(double promo)
        {
            this.promo = promo;
        }

        public void updateTotal(double subtotal)
        {
            double total = subtotal + deliveryFee - promo;
            this.balance = this.balance - total;
            this.paymentCallback.onPriceUpdated(subtotal, total, balance);
        }

    }

    interface OnPaymentChangedListener
    {
        void onPriceUpdated(double subtotal, double grantTotal, double balance);
    }
}
