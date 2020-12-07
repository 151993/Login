import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { Product } from 'src/app/Models/product';
import { ProductService } from '../product.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit, OnDestroy {
  subscription: Subscription;
  productList: Product[];
  pageSize = 5;
  page = 1;
  constructor(private productService: ProductService) { }

  ngOnInit(): void {
    this.GetProductList();
  }

  GetProductList = (): void => {
    this.subscription = this.productService.GetProductList().subscribe(response => {
      this.productList = response;
    });
  }

  ngOnDestroy = (): void => {
    if (this.subscription) { this.subscription.unsubscribe(); }
  }
}
