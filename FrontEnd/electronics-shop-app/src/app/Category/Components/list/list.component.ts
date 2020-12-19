import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { CategoryService } from '../../Services/category.service';
import { GridDataResult, PageChangeEvent, GridComponent, DataStateChangeEvent } from '@progress/kendo-angular-grid';
import { process, State } from '@progress/kendo-data-query';
import { DropDownFilterSettings } from '@progress/kendo-angular-dropdowns';


@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private categoryService: CategoryService,
    // private paginationService: PaginationService
  ) { }


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


  ngOnInit() {
    // this.categoryService.getAllCategories(0,5).subscribe(result=>{
    //   console.log(result);
    // });

    this.pageSize = 5;
    this.getList();
    this.extractRouteParams();
  }

  getList() {
    // this.postSearch.pageSize = this.pageSize;
    // this.postSearch.pageIndex = this.pageIndex;

    this.categoryService.getAllCategories(this.pageIndex, this.pageSize)
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

  extractRouteParams() {
    let pageIndex = +this.route.snapshot.params['pageIndex'];

    this.pageIndex = 0;
    if (pageIndex) {
      this.pageIndex = pageIndex;
      this.skip = this.pageIndex * this.pageSize;  
    }
  }

  dataStateChange(state: DataStateChangeEvent): void {
    this.skip = state.skip;
    this.pageIndex = (this.skip / this.pageSize);
    this.state = state;
    this.filter = this.state.filter.filters;
    // if (this.filter.length > 0) {
    //   for (var _i = 0; _i < this.filter.length; _i++) {
    //     if (this.filter[_i].filters) {
    //       var x = this.filter[_i].filters;
    //       // this.postSearch.dateFrom = x[0].value.toISOString().substring(0, 10);
    //       // this.postSearch.dateTo = x[1].value.toISOString().substring(0, 10);
    //       //this.filter.splice( _i,1);      
    //     } else {
    //       // this.postSearch.dateFrom = new Date(new Date().setMonth(new Date().getMonth() - 1)).toISOString().substring(0, 10);
    //       // this.postSearch.dateTo = new Date(Date.now()).toISOString().substring(0, 10);
    //     }

    //     // if (this.filter[_i].field == "code") {
    //     //   this.postSearch.code = this.filter[_i].value;
    //     // }

    //     // if (this.filter[_i].field == "date") {
    //     //   this.postSearch.dateFrom = this.filter[_i].value.toISOString().substring(0, 10);
    //     //   this.postSearch.dateTo = new Date(Date.now()).toISOString().substring(0, 10);
    //     // }

    //   }
    //   this.postSearch.filters = this.filter;
    //   this.pageIndex = 0;
    // } else {
    //   this.postSearch = new PostSearch();
    // //   this.postSearch.bank = this.bank;
    // //   this.postSearch.journalType = this.journalType;
    // }
    // //debugger;
    // this.postSearch.sort = this.state.sort;
    this.getList();
  }

  public pageChange(event: PageChangeEvent): void {
    this.pageIndex = (event.skip / this.pageSize);

    let url = [`/category/list/${this.pageIndex}`];
    this.router.navigate(url);
  }

}
