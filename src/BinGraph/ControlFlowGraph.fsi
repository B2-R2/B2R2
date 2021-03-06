(*
  B2R2 - the Next-Generation Reversing Platform

  Copyright (c) SoftSec Lab. @ KAIST, since 2016

  Permission is hereby granted, free of charge, to any person obtaining a copy
  of this software and associated documentation files (the "Software"), to deal
  in the Software without restriction, including without limitation the rights
  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
  copies of the Software, and to permit persons to whom the Software is
  furnished to do so, subject to the following conditions:

  The above copyright notice and this permission notice shall be included in all
  copies or substantial portions of the Software.

  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
  SOFTWARE.
*)

namespace B2R2.BinGraph

/// A simple directed graph, which represents any kinds of control-flow graphs
/// (including call graphs). Vertex Data should support equality operation in
/// order to support FindVertexByData method. Any graph that inherits from this
/// class operates with our visualizer.
type ControlFlowGraph<'V, 'E when 'V :> BasicBlock and 'V : equality> =
  inherit SimpleDiGraph<'V, 'E>

  new: unit -> ControlFlowGraph<'V, 'E>

  /// Clone this graph and return a new one. Copied vertices will have the same
  /// IDs assigned. The reverse parameter tells whether the graph is constructed
  /// with transposed (reversed) edges or not. If the parameter is not given,
  /// this function will simply return the same graph by default.
  member Clone: ?reverse: bool -> ControlFlowGraph<'V, 'E>

  /// Return a subgraph induced by given set of vertices
  member SubGraph: Set<Vertex<'V>> -> ControlFlowGraph<'V, 'E>

/// The main construct of any kind of CFG. We always build an IR-based CFG
/// first, and then convert it into another type of CFG, such as SSA and
/// disassembly-based CFG.
type IRCFG = ControlFlowGraph<IRBasicBlock, CFGEdgeKind>

// vim: set tw=80 sts=2 sw=2:
