import { Data } from './../models/data';
import { BaseService } from './../services/base.service';
import { ReserverdDays } from './../models/reservedDays';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { EChartOption } from 'echarts';
import 'echarts/src/chart/bar';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  public chartOption: EChartOption;
  public idUser: number;
  public reserverdDays: ReserverdDays[];
  public dates: string[];
  public quantity: number[];

  constructor(private baseService: BaseService) {
    // this.GetMostReservedDays();
    // this.fillReservedDaysChart();
   }

  ngOnInit(): void {
    this.idUser = 1;
  }

  // tslint:disable-next-line:typedef
  fillReservedDaysChart(){
    this.chartOption =  {
      xAxis: {
        type: 'category',
        data: this.dates,
      },
      yAxis: {
        type: 'value',
      },
      series: [
        {
          data: this.quantity,
          type: 'bar',
        },
      ],
    };
  }
  // tslint:disable-next-line:typedef
  GetMostReservedDays(){
    this.baseService.GetMostReservedDays().subscribe((reserved: string) =>
    {
      const usersJson: Data[] = Array.of(reserved.json());
      console.log(usersJson);
      
      
      
      // this.dates = reserved.data.map(daysIn =>
      // {
      //   return daysIn.ReservedDay;
      // });

      // this.quantity = reserved.data.map(daysIn =>
      //   {
      //     return Number(daysIn.Quantity);
      //   });
    });
  }
}
