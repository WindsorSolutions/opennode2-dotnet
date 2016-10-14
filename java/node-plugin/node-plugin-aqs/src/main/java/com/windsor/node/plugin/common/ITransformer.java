package com.windsor.node.plugin.common;

import org.apache.commons.collections.Transformer;

public abstract interface ITransformer<IN, OUT>
  extends Transformer
{
  public abstract OUT typedTransform(IN paramIN);
}


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\common\ITransformer.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */