import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { Product } from 'src/app/Models/product';
import { ProductService } from '../product.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit, OnDestroy {
  subscription: Subscription;
  product: any;
  productId: string;
  constructor(
     private productService: ProductService,
     private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.productId = this.route.snapshot.params.id;
    this.GetProductDetail(this.productId);
  }

  GetProductDetail = (id): void => {
    this.subscription = this.productService.GetProductDetailById(id).subscribe(response => {
      if (response) {
        this.product = response;
      }
    });
  }

  // ngAfterViewInit = (): void => {
  //   this.subscription = this.productService.GetProductDetailById(this.productId).subscribe(response => {
  //     if (response) {
  //       this.product = response;
  //     }
  //   });
  // }

  ngOnDestroy = (): void => {
    if (this.subscription) { this.subscription.unsubscribe(); }
  }

}
