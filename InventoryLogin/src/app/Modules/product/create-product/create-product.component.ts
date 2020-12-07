import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Product } from 'src/app/Models/product';
import { ProductService } from '../product.service';

@Component({
  selector: 'app-create-product',
  templateUrl: './create-product.component.html',
  styleUrls: ['./create-product.component.css']
})
export class CreateProductComponent implements OnInit, OnDestroy {
  form: FormGroup = new FormGroup({});
  product: Product;
  subscription: Subscription;
  isCreate = true;
  productId: string;
  submitted = false;
  constructor(
    private fb: FormBuilder,
    private productService: ProductService,
    private router: Router,
    private route: ActivatedRoute) { }

  ngOnInit(): void {

    this.CheckIsCreateOrUpdateComponent();
    this.InitialObject();
    this.FormBuilder();
  }

  CheckIsCreateOrUpdateComponent = (): void => {
    this.route.data.subscribe(param => {
      if (param && param.action) {
        this.isCreate = param.action === 'update' ? false : true;
        this.productId = this.route.snapshot.params.id;
        this.GetProductDetail(this.productId);
      }
    });
  }

  FormBuilder = (): void => {
    this.form = this.fb.group({
      name: ['', [Validators.required, Validators.maxLength(50)]],
      price: ['', [Validators.required]],
      quantity: ['', [Validators.required, Validators.pattern(/^-?(0|[1-9]\d*)?$/)]],
    });
  }

  InitialObject = (): void => {
    this.product = { ProductId: '', Name: '', Price: 0, Quantity: 0, CreatedDate: null, UpdatedDate: null };
  }

  onSubmit = (): void => {
    this.submitted = true;

    if (this.form.invalid) {
      return;
    }
    this.product =
    {
      ProductId: this.isCreate ? '' : this.productId,
      Name: this.form.get('name').value,
      Price: this.form.get('price').value,
      Quantity: this.form.get('quantity').value,
      CreatedDate: null,
      UpdatedDate: null
    };

    if (this.isCreate) {

      this.subscription = this.productService.Save(this.product).subscribe(response => {
        if (response.isSuccess) {
          alert(response.successMessage);
          this.router.navigate(['product/list']);
        }
      });
    }
    else {
      this.subscription = this.productService.Update(this.product).subscribe(response => {
        if (response.isSuccess) {
          alert(response.successMessage);
          this.router.navigate(['product/list']);
        }
      });
    }
  }

  GetProductDetail = (id): void => {
    this.subscription = this.productService.GetProductDetailById(id).subscribe(response => {
      if (response) {
        this.InitilizeData(response);
      }
    });
  }

  InitilizeData = (data): void => {
    this.form.patchValue({
      name: data.name,
      price: data.price,
      quantity: data.quantity,
    });
  }

  Clear = (): void => {
    this.form.reset();
  }

  // tslint:disable-next-line: typedef
  get f() { return this.form.controls; }

  ngOnDestroy = (): void => {
    if (this.subscription) { this.subscription.unsubscribe(); }
  }
}
