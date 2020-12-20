import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DropDownFilterSettings } from '@progress/kendo-angular-dropdowns';
import { DataStateChangeEvent, GridDataResult, PageChangeEvent } from '@progress/kendo-angular-grid';
import { State } from '@progress/kendo-data-query';
import { OrderService } from '../../Services/order.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {


  gridView: GridDataResult;
  pageSize: number;
  pageIndex: number = 0;
  skip: number = 0;
  filter: any;

  public state: State = {
    filter: {
      logic: 'and',
      filters: []
    }
  };

  public filterSettings: DropDownFilterSettings = {
    caseSensitive: false,
    operator: 'contains'
  };


  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private orderService: OrderService,
  ) { }

  ngOnInit() {
    this.pageSize = 5;
    this.getList();
    this.extractRouteParams();
  }

  extractRouteParams() {
    let pageIndex = +this.route.snapshot.params['pageIndex'];
    if (pageIndex) {
      this.pageIndex = pageIndex;
      this.skip = this.pageIndex * this.pageSize;  
      this.getList();
    }else{
      this.pageIndex = 0;
      this.getList();
    }
  }

  getList() {

    this.orderService.getAllOrders(this.pageIndex, this.pageSize)
      .subscribe(res => {
        this.gridView = {
          data: res.collection,
          total: res.totalCount
        };
        console.log(res)
      },
        (error) => {
          console.log(error);
        },
      );
  }

  dataStateChange(state: DataStateChangeEvent): void {
    this.skip = state.skip;
    this.pageIndex = (this.skip / this.pageSize);
    this.state = state;
    this.filter = this.state.filter.filters;
    this.getList();
  }

  public pageChange(event: PageChangeEvent): void {
    this.pageIndex = (event.skip / this.pageSize);

    let url = [`/order/list/${this.pageIndex}`];
    this.router.navigate(url);
  }

}
