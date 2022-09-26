import "reflect-metadata";
import { App } from "zes-unity-jslib";
import { Root } from "./lib/root";

App.bootstrap(Root, "root");

// function wait(): Promise<void> {
//     return new Promise(resolve => {
//         setTimeout(() => {
//             resolve();
//         }, 1000);
//     })
// }

// let watiCount = 0;

// export function i18n(id: number): string {
//     return `id is ${id}`;
// }

// export async function testFunc() {
//     while (watiCount >= 0) {
//         await wait();
//         console.log(`wait ...${watiCount}`);
//         watiCount++;
//     }
// }



